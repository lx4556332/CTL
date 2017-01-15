var app = angular.module("createFlow", []);

app.controller("flowDataCtrl", function ($scope, $http) {

    $scope.divideGroup = false;

    //Залишок кількості не розподілених студентів між підгрупами
    $scope.residual = 0;

    //Тип та форма навчання
    $scope.edu = {
        types: ["Бюджет", "Контракт"],
        forms: ["Денна","Заочна"]
    }
    //Об'єкт потік
    $scope.flow = {
        name: "",
        allCountBudget: 0,
        allCountContract: 0,
        studentsCountTotal: 0,
        educationType: "",
        educationForm: "",
        countSubGroupBudget: 0,
        countSubGroupContract: 0,
        countStudSubGroupBudget: 0,
        countStudSubGroupContract: 0,
        subGroupList: [],
        selectedGroupList: []
    }

    //Об'єкт підгрупа 
    $scope.subGroup = {
        Id: 0,
        Name: "",
        CountStudent: 0
    }

    //Отримання даних про групи
    $scope.httpGetGroup = function () {
        var promise = $http.get("../InputDataFlow/GetGroup");
        promise.then(fulfilled, rejected)
    }

    $scope.httpGetGroup();

    //Відправка даних для створення потоку
    $scope.httpPostFlow = function () {
        var host = location.host;
        $http.post("http://"+ host +"/Admin/InputDataFlow/CreateFlow", $scope.flow).success(function () {
            alert("Дані про потік успішно додані до БД");
        }).error(function () {
            alert("Помилка створення даних про потік!");
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
                    CountStudent: $scope.flow.countStudSubGroupBudget
                });

                $scope.flow.subGroupList.push($scope.subGroup);
                $scope.residual -= $scope.flow.countStudSubGroupBudget;
            }
        }
        else {

            $scope.subGroup = new Object({
                Id: Math.random().toString(36).substr(2, 9),
                Name: item.Name,
                CountStudent: $scope.flow.countStudSubGroupBudget
            });

            $scope.flow.subGroupList.push($scope.subGroup);
            $scope.residual -= $scope.flow.countStudSubGroupBudget;
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

    //Відміна редагування
    $scope.cancelEditSubGroup = function () {
        $scope.currentItem = {};
    }

    //Розрахунок залишку не розподілених студентів
    function calculateResidual() {
        var sum = 0;

        for (var i = 0; i < $scope.flow.subGroupList.length; i++) {
            sum += $scope.flow.subGroupList[i].CountStudent;
        }
        $scope.residual = $scope.flow.studentsCountTotal - sum;
    }

    //Додавання студентів до потоку
    function addCountStud(item) {
        $scope.flow.name += item.Name + " ";
        $scope.flow.allCountBudget += item.StudentsCountBudget;
        $scope.flow.allCountContract += item.StudentsCountContract;
        $scope.flow.studentsCountTotal += item.StudentsCountTotal;
        $scope.residual += item.StudentsCountTotal;
    }

    //Видалення студентів з потоку
    function removeCountStud(item) {
        $scope.flow.name = $scope.flow.name.replace(item.Name + " ", "");
        $scope.flow.allCountBudget -= item.StudentsCountBudget;
        $scope.flow.allCountContract -= item.StudentsCountContract;
        $scope.flow.studentsCountTotal -= item.StudentsCountTotal;
        $scope.residual -= item.StudentsCountTotal;

    }
    
    //Розрахунок кількості 
    function calculateCountSubGroup() {

        var countStudentBudget = $scope.flow.allCountBudget;
        var countStudentContract = $scope.flow.allCountContract;
        var countSubGroupBudget = 0;
        var countSubGroupContract = 0;

        if ((countStudentBudget % 15) >= 10) {

            countSubGroupBudget =  Math.round(countStudentBudget / 15);
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

            if ((countStudentContract / countSubGroupContract) >= 19 && countSubGroupContract != 0) {

                countSubGroupContract++;
            }
        }

        $scope.flow.countSubGroupBudget = countSubGroupBudget;
        $scope.flow.countSubGroupContract = countSubGroupContract;

        $scope.flow.countStudSubGroupBudget = (countSubGroupBudget == 0) ? countStudentBudget : Math.round(countStudentBudget / countSubGroupBudget);
        $scope.flow.countStudSubGroupContract = (countSubGroupContract == 0) ? countStudentContract : Math.round(countStudentContract / countSubGroupContract);
    }

    //Result promise виконано
    function fulfilled(response) {

        console.log("Status: " + response.status); // status - статус код полученный от сервера
        console.log("Type: " + response.headers("content-type")); // headers - метод для чтения заголовков ответа
        console.log("Length: " + response.headers("content-length"));

        $scope.groupList = response.data; // data - данные запроса
    }

    //Result promise відхилено
    function rejected(error) {
        console.error(error.status);
        console.error(error.statusText);
        alert("Помилка завантаження даних про Групи!");
    }
});