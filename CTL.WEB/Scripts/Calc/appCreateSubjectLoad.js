var app = angular.module("createSubjectLoad", []);

app.controller("subjectLoadCtrl", function ($scope, $http) {

    //Об'єкт навантаження на дисципліну
    $scope.subjectData = {
        SubjectId: 0,
        Name: "",
        ShortName: "",
        Semestr: 0,
        FlowId: 0,
        FlowName: "",

        SubjectInfoBId: 0,
        LectionB: 0,
        PracticeB: 0,
        LabB: 0,
        ExamB: 0,
        CreditB: 0,
        TestB: 0,
        CourseProjectB: 0,
        CourseWorkB: 0,
        RgrB: 0,
        DkrB: 0,
        SummeryB: 0,
        ConsultationB: 0,
        TotalHoursB: 0,

        SubjectInfoKId: 0,
        LectionK: 0,
        PracticeK: 0,
        LabK: 0,
        ExamK: 0,
        CreditK: 0,
        TestK: 0,
        CourseProjectK: 0,
        CourseWorkK: 0,
        RgrK: 0,
        DkrK: 0,
        SummeryK: 0,
        ConsultationK: 0,
        TotalHoursK: 0
    };

    $scope.flowList = [];
    $scope.subGroupList = [];

    $scope.hoursToCalculate = {
        AmountHours: 0,
        Lection: 0,
        Practice: 0,
        Lab: 0,
        Exam: 0,
        Credit: 0,
        Test: 0,
        CourseProject: 0,
        CourseWork: 0,
        Rgr: 0,
        Dkr: 0,
        Summery: 0,
        AcademB: 0,
        AcademK: 0,
        SubGroupPractB: 0,
        SubGroupPractK: 0,
        SubGroupLabB: 0,
        SubGroupLabK: 0,
        StudCountB: 0,
        StudCountK: 0,
        flow: {}
    };

    ////Об'єкт потік 
    //$scope.flow = {
    //    name: "",
    //    AllCountBudget: 0,
    //    AllCountContract: 0,
    //    EducationType: "",
    //    EducationForm: "",
    //    CountSubGroupBudget: 0,
    //    CountSubGroupContract: 0,
    //    CountStudSubGroupBudget: 0,
    //    CountStudSubGroupContract: 0,
    //    subGroupList: [],
    //    selectedGroupList: []
    //}

    ////Об'єкт підгрупа 
    //$scope.subGroup = {
    //    Id: 0,
    //    Name: "",
    //    CountStudent: 0
    //}

    //Отримання даних про потіки
    $scope.httpGetFlow = function () {
        var host = location.host;
        $http.get("http://" + host + "/api/Flow/").success(function (data) {
            $scope.flowList = data;
        }).error(function () {
            alert("Помилка завантаження даних про потік!");
        });
    };

    $scope.httpGetFlow();

    //Вибір потоку для дисципліни
    $scope.getCurrentFlow = function (item) {
        $scope.subGroupList = item.subGroupList;

        var countB = 0;
        var countK = 0;

        for (var i = 0; i < item.selectedGroupList.length; i++) {
            if (item.selectedGroupList[i].EducationType == "Бюджет") {
                countB++;
            }
            else if (item.selectedGroupList[i].EducationType == "Контракт") {
                countK++;
            }
        }

        $scope.subjectData.FlowId = item.Id;
        $scope.subjectData.FlowName = item.Name;

        $scope.hoursToCalculate.flow = item;
        $scope.hoursToCalculate.AcademB = countB;
        $scope.hoursToCalculate.AcademK = countK;
        $scope.hoursToCalculate.SubGroupPractB = countB;
        $scope.hoursToCalculate.SubGroupPractK = countK;
        $scope.hoursToCalculate.SubGroupLabB = item.CountSubGroupBudget;
        $scope.hoursToCalculate.SubGroupLabK = item.CountSubGroupContract;
        $scope.hoursToCalculate.StudCountB = item.AllCountBudget;
        $scope.hoursToCalculate.StudCountK = item.AllCountContract;
    };

    //Збереження даних про навантаження на дисципліну
    $scope.httpPostSaveSubjectLoad = function () {
        var host = location.host;

        $http.post("http://" + host + "/Admin/CalcSubjectLoad/CreateSubjectLoad", $scope.subjectData).success(function () {
            alert("Дані про навантаження на дисципліну збережені!");
        }).error(function () {
            alert("Помилка збереження даних про навантаження на дисципліну!");
        });
        console.log($scope.subjectData);
    };


    //Отримання даних про дисципліну
    $scope.httpGetSubjectData = function () {
        var host = location.host;
        var path = location.pathname.split('/');
        var id = path[path.length - 1];

        $http.get("http://" + host + "/api/SubjectLoad/" + id).success(function (data) {
            console.log(data);
            $scope.subjectData = data;
        }).error(function () {
            alert("Помилка завантаження даних про дисципліну!");
        });
    };

    $scope.httpGetSubjectData();

    //Розрахунок навантаження на дисципліну
    $scope.httpCalculateSubjectLoad = function (hoursToCalculate) {
        var host = location.host;

        $http.post("http://" + host + "/api/SubjectLoad/", hoursToCalculate).success(function (data) {
            $scope.subjectData.LectionB = data.LectionB;
            $scope.subjectData.PracticeB = data.PracticeB;
            $scope.subjectData.LabB = data.LabB;
            $scope.subjectData.ExamB = data.ExamB;
            $scope.subjectData.CreditB = data.CreditB;
            $scope.subjectData.TestB = data.TestB;
            $scope.subjectData.CourseProjectB = data.CourseProjectB;
            $scope.subjectData.CourseWorkB = data.CourseWorkB;
            $scope.subjectData.RgrB = data.RgrB;
            $scope.subjectData.DkrB = data.DkrB;
            $scope.subjectData.SummeryB = data.SummeryB;
            $scope.subjectData.ConsultationB = data.ConsultationB;
            $scope.subjectData.TotalHoursB = data.TotalHoursB;

            $scope.subjectData.LectionK = data.LectionK;
            $scope.subjectData.PracticeK = data.PracticeK;
            $scope.subjectData.LabK = data.LabK;
            $scope.subjectData.ExamK = data.ExamK;
            $scope.subjectData.CreditK = data.CreditK;
            $scope.subjectData.TestK = data.TestK;
            $scope.subjectData.CourseProjectK = data.CourseProjectK;
            $scope.subjectData.CourseWorkK = data.CourseWorkK;
            $scope.subjectData.RgrK = data.RgrK;
            $scope.subjectData.DkrK = data.DkrK;
            $scope.subjectData.SummeryK = data.SummeryK;
            $scope.subjectData.ConsultationK = data.ConsultationK;
            $scope.subjectData.TotalHoursK = data.TotalHoursK;

            console.log($scope.subjectData);
        }).error(function () {
            alert("Помилка розподілу годин!");
        });
    };

    $scope.clearCalc = function () {
        $scope.hoursToCalculate = {};
    };

    $scope.clearSubjectInfoB = function () {

        $scope.subjectData.LectionB = 0;
        $scope.subjectData.PracticeB = 0;
        $scope.subjectData.LabB = 0;
        $scope.subjectData.ExamB = 0;
        $scope.subjectData.CreditB = 0;
        $scope.subjectData.TestB = 0;
        $scope.subjectData.CourseProjectB = 0;
        $scope.subjectData.CourseWorkB = 0;
        $scope.subjectData.RgrB = 0;
        $scope.subjectData.DkrB = 0;
        $scope.subjectData.SummeryB = 0;
        $scope.subjectData.ConsultationB = 0;
        $scope.subjectData.TotalHoursB = 0;
    };

    $scope.clearSubjectInfoK = function () {
        $scope.subjectData.LectionK = 0;
        $scope.subjectData.PracticeK = 0;
        $scope.subjectData.LabK = 0;
        $scope.subjectData.ExamK = 0;
        $scope.subjectData.CreditK = 0;
        $scope.subjectData.TestK = 0;
        $scope.subjectData.CourseProjectK = 0;
        $scope.subjectData.CourseWorkK = 0;
        $scope.subjectData.RgrK = 0;
        $scope.subjectData.DkrK = 0;
        $scope.subjectData.SummeryK = 0;
        $scope.subjectData.ConsultationK = 0;
        $scope.subjectData.TotalHoursK = 0;
    };
});