// Setup global object with modules
var SamplesJs = {
    Pages: {
        DataTable: {}
    },
    DataTableFunctions: {
        initSearch: function ($txtSearch, dataTable) {
            $txtSearch.on('keyup', function () {
                dataTable.search(this.value).draw();
            });
        }
    }
};