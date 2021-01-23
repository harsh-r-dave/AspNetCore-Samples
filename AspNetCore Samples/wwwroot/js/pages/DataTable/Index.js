SamplesJs.Pages.DataTable.Index = function () {
    var initDataTable = function () {
        var dt = $('#example').DataTable();

        SamplesJs.DataTableFunctions.initSearch($('#dt_search'), dt);
    };

    var init = function () {
        initDataTable();
    };

    return {
        init: init
    };
}();

