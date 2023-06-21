$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#productTable').DataTable({
        "ajax": { url:'/admin/product/getall'},
        "columns": [
            { data: 'productName', "width": "15%" },
            { data: 'productType', "width": "15%" },
            { data: 'batchNumber', "width": "15%" },
            { data: 'listPrice', "width": "15%" },
            { data: 'price', "width": "15%" },
            { data: 'category.name', "width": "15%" }
        ]
    });
}
