var app = angular.module("editFlow", []);

app.controller("flowDataCtrl", function ($scope, $http) {

    $scope.divideGroup = false;

    //Залишок кількості не розподілених студентів між підгрупами
    $scope.residual = 0;

    //Тип та форма навчання
    $scope.edu = {
        types: ["Бюджет", "Контракт"],
        forms: ["Денна", "Заочна"]
    }
    //Об'єкт потік
    $scope.flow = {
        Id: 0,
        Name: "",
        AllCountBudget: 0,
        AllCountContract: 0,
        StudentsCountTotal: 0,
        EducationType: "",
        EducationForm: "",
        CountSubGroupBudget: 0,
        CountSubGroupContract: 0,
        CountStudSubGroupBudget: 0,
        CountStudSubGroupContract: 0,
        subGroupList: [],
        selectedGroupList: []
    }

    $scope.groupList = [];

    //Об'єкт підгрупа 
    $scope.subGroup = {
        Id: 0,
        Name: "",
        CountStudent: 0
    }

    //Отримання даних про групи
    $scope.httpGetGroup = function () {
        $http.get("../GetGroup").success(function (data) {
            $scope.groupList = data;
        });
    }

    $scope.httpGetGroup();

    //Отримання даних про потік
    $scope.httpGetFlow = function () {
        var host = location.host;
        var path = location.pathname.split('/');
        var id = path[path.length - 1];

        $http.get("http://" + host + "/api/Flow/" + id).success(function (data) {
            for (var i = 0; i < $scope.groupList.length; i++) {
                for (var j = 0; j < data.selectedGroupList.length; j++) {
                    if ($scope.groupList[i].Id == data.selectedGroupList[j].Id) {
                        $scope.groupList[i].Selected = true;
                        $scope.addRemoveGroup($scope.groupList[i])
                    }
                }
            }

            $scope.flow.Id = data.Id;
            $scope.flow.Name = data.Name;
            $scope.flow.AllCountBudget = data.AllCountBudget;
            $scope.flow.AllCountContract = data.AllCountContract;
            $scope.flow.EducationType = data.EducationType;
            $scope.flow.EducationForm = data.EducationForm;
            $scope.flow.CountSubGroupBudget = data.CountSubGroupBudget;
            $scope.flow.CountSubGroupContract = data.CountSubGroupContract;
            $scope.flow.subGroupList = data.subGroupList;
            
            calculateResidual();

            console.log(data.selectedGroupList);

            console.log($scope.flow.selectedGroupList);

        }).error(function () {
            alert("Помилка завантаження даних для редагування потоку!");
        });
    }

    $scope.httpGetFlow();

    //Відправка даних для редагування потоку
    $scope.httpPostFlow = function () {
        var host = location.host;

        $http.post("http://" + host + "/api/Flow/", $scope.flow).success(function () {
            alert("Дані про потік успішно збережені!");
        }).error(function () {
            alert("Помилка редагування даних про потік!");
        });
    }

    //Отримання даних про підгрупи
    $scope.httpGetSubGroup = function () {
        var host = location.host;

        $http.get("http://" + host + "/api/SubGroup/").success(function (data) {
            $scope.flow.subGroupList = data
        }).error(function () {
            alert("Помилка отримання даних про підгрупу!");
        });
    }

    //Відправка даних для створення підгрупи
    $scope.httpPostSubGroup = function (subGroup) {
        var host = location.host;

        $http.post("http://" + host + "/api/SubGroup/", subGroup).success(function () {
            $scope.flow.subGroupList.push(subGroup);
            $scope.residual -= $scope.flow.CountStudSubGroupBudget;
        }).error(function () {
            alert("Помилка створення даних про підгрупу!");
        });
    }

    //Відправка даних для редагування підгрупи
    $scope.httpPutSubGroup = function (subGroup) {
        var host = location.host;
        
        $http.put("http://" + host + "/api/SubGroup/" + subGroup.Id, subGroup).success(function () {
            $scope.updateSubGroup(subGroup);
        }).error(function () {
            alert("Помилка редагування даних про підгрупу!");
        });
    }

    //Видалення даних про підгрупу
    $scope.httpDeleteSubGroup = function (subGroup) {
        var host = location.host;

        $http.delete("http://" + host + "/api/SubGroup/" + subGroup.Id).success(function () {
            $scope.deleteSubGroup(subGroup);
            alert("Дані про підгрупу успішно видалені!");
        }).error(function () {
            alert("Помилка видалення даних про підгрупу!");
        });
    }

    //Додавання чи видалення групи до списку для розподілу
    $scope.addRemoveGroup = function (item) {
        if (item.Selected) {

            item.divideGroup = $scope.divideGroup;
            $scope.flow.selectedGroupList.push(item);

            addCountStud(item);
            calculateCountSubGroup();
        }
        else {

            $scope.flow.selectedGroupList.splice($scope.flow.selectedGroupList.indexOf(item), 1);

            removeCountStud(item);
            calculateCountSubGroup();
        }
    }

    //Розподіл групи на підгрупи
    $scope.dividedGroup = function (item) {

        if (item.divideGroup) {

            for (var i = 1; i <= 2; i++) {

                $scope.subGroup = new Object({
                    Id: Math.random().toString(36).substr(2, 9),
                    Name: item.Name + "_" + i + (i == 1 ? "Б" : "К"),
                    CountStudent: $scope.flow.CountStudSubGroupBudget,
                    FlowId: $scope.flow.Id
                });

                $scope.httpPostSubGroup($scope.subGroup);
            }
        }
        else {

            $scope.subGroup = new Object({
                Id: Math.random().toString(36).substr(2, 9),
                Name: item.Name,
                CountStudent: $scope.flow.CountStudSubGroupBudget,
                FlowId: $scope.flow.Id
            });

            $scope.httpPostSubGroup($scope.subGroup);
        }
    }

    //Редагування даних про підгрупу
    $scope.editSubGroup = function (item) {
        $scope.currentItem = angular.copy(item);
    }

    //Оновлення даних про підгрупу
    $scope.updateSubGroup = function (item) {
        for (var i = 0; i < $scope.flow.subGroupList.length; i++) {

            if ($scope.flow.subGroupList[i].Id == item.Id) {

                $scope.flow.subGroupList[i] = item;

                $scope.currentItem = {};
                calculateResidual();

                break;
            }
        }
    }

    //Видалення даних про підгруппу
    $scope.deleteSubGroup = function (item) {
        $scope.flow.subGroupList.splice($scope.flow.subGroupList.indexOf(item), 1);

        calculateResidual();
    }

    //Відміна редагування підгрупи
    $scope.cancelEditSubGroup = function () {
        $scope.currentItem = {};
    }

    //Розрахунок залишку не розподілених студентів
    function calculateResidual() {
        var sum = 0;

        for (var i = 0; i < $scope.flow.subGroupList.length; i++) {
            sum += $scope.flow.subGroupList[i].CountStudent;
        }
        $scope.residual = $scope.flow.StudentsCountTotal - sum;
    }

    //Додавання студентів до потоку
    function addCountStud(item) {
        $scope.flow.Name += item.Name + " ";
        $scope.flow.AllCountBudget += item.StudentsCountBudget;
        $scope.flow.AllCountContract += item.StudentsCountContract;
        $scope.flow.StudentsCountTotal += item.StudentsCountTotal;
        $scope.residual += item.StudentsCountTotal;
    }

    //Видалення студентів з потоку
    function removeCountStud(item) {
        $scope.flow.Name = $scope.flow.Name.replace(item.Name + " ", "");
        $scope.flow.AllCountBudget -= item.StudentsCountBudget;
        $scope.flow.AllCountContract -= item.StudentsCountContract;
        $scope.flow.StudentsCountTotal -= item.StudentsCountTotal;
        $scope.residual -= item.StudentsCountTotal;

    }

    //Розрахунок кількості підгруп та студентів
    function calculateCountSubGroup() {

        var countStudentBudget = $scope.flow.AllCountBudget;
        var countStudentContract = $scope.flow.AllCountContract;
        var countSubGroupBudget = 0;
        var countSubGroupContract = 0;

        if ((countStudentBudget % 15) >= 10) {

            countSubGroupBudget = Math.round(countStudentBudget / 15);
        }
        else {

            countSubGroupBudget = (Math.round(countStudentBudget / 15) <= 1) ? 0 : Math.round(countStudentBudget / 15);

            if ((countStudentBudget / countSubGroupBudget) >= 19) {

                countSubGroupBudget++;
            }
        }

        if ((countStudentContract % 15) >= 10) {

            countSubGroupContract = Math.round(countStudentContract / 15);
        }
        else {

            countSubGroupContract = (Math.round(countStudentContract / 15) <= 1) ? 0 : Math.round(countStudentContract / 15);

            if ((countStudentContract / countSubGroupContract) >= 19) {

                countSubGroupContract++;
            }
        }

        $scope.flow.CountSubGroupBudget = countSubGroupBudget;
        $scope.flow.CountSubGroupContract = countSubGroupContract;

        $scope.flow.countStudSubGroupBudget = (countSubGroupBudget == 0) ? countStudentBudget : Math.round(countStudentBudget / countSubGroupBudget);
        $scope.flow.countStudSubGroupContract = (countSubGroupContract == 0) ? countStudentContract : Math.round(countStudentContract / countSubGroupContract);
    }
});