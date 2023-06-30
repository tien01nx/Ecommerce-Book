var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": '/admin/coupon/getall'
        },
        "columns": [
            { data: 'code', "width": "10%" },
            { data: 'description', "width": "20%" },
            { data: 'discountAmount', "width": "10%" },
            { data: 'minimumSpend', "width": "10%" },
            { data: 'startDate', "width": "10%" },
            { data: 'endDate', "width": "10%" },
            { data: 'maxUseTimes', "width": "10%" },
            { data: 'usedTimes', "width": "10%" },
            { data: 'applyForAllProducts', "width": "10%" },
            { data: 'isActive', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/coupon/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit </a>
                        <a onClick="Delete('/admin/coupon/delete/${data}')" class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete </a>
                    </div>`;
                }, "width": "10%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            });
        }
    });
}
