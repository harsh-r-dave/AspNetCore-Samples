if ($.fn.dataTable) {
    $.extend(true, $.fn.dataTable.defaults, {
        "retrieve": true,
        "dom": 'r<"voffset2" t><"bottom row mt-3"<"col-12 col-sm-6 col-md-6 col-lg-4 text-right"><"col-sm-12 d-md-none text-left" i><"col-lg-4 d-none d-lg-block text-center" i><"col-12 d-md-none" lp><"col-md-6 col-lg-4 d-none d-md-block text-right" lp><"col-md-12 d-lg-none d-none d-md-block text-left" i>><"clear">'
    });
}