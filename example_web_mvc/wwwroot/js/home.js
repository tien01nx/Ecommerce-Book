$(document).ready(function () {
    var page = 2;

    $('#loadMore').click(function () {
        $.ajax({
            url: '/Customer/Home/Index',
            data: { page: page },
            type: 'GET',
            headers: { "X-Requested-With": "XMLHttpRequest" },
            success: function (data) {
                $('#additionalProducts').append(data);
                page++;
                if (page > '@Model.PageCount') {
                    $('#loadMore').hide();
                }
              
            }
        });
    });
});
