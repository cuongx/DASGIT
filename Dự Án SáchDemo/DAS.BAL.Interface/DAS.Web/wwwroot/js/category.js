var category = {} || category;

category.drawTable = function () {
    $.ajax({
        url: "/Category/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbCategory tbody').empty();
            $.each(data.categorys, function (i, v) {
                $('#tbCategory tbody').append(
                    `<tr>
                        <td>${v.categoryId}</td>
                        <td>${v.categoryName}</td>
                        <td><a href="/Book/Index/${v.categoryId}" title="Book list">${v.soluongSach}</a></td>
                        <td>
                            <a href="javascripts:;"
                                       onclick="category.get(${v.categoryId})"><i class="fas fa-edit"></i></a> 
                            <a href="javascripts:;" class="item"
                                        onclick="category.delete(${v.categoryId})"><i class="zmdi zmdi-delete"></i></a>
                        </td>
                    </tr>`
                );
            });
        }
    });

};

category.openAddEditCategory = function () {
    category.reset();
    $('#addEditCategory').appendTo("body").modal('show');
};


category.delete = function (id) {
    bootbox.confirm({
        title: "Delete category?",
        message: "Do you want to delete this category.",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Yes'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Category/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.result.message);
                        category.drawTable();
                    }
                });
            }
        }
    });
}


category.get = function (id) {
    $.ajax({
        url: `/Category/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#CategoryName').val(data.result.categoryName);
            $('#CategoryId').val(data.result.categoryId);
            $('#addEditCategory').modal('show');
        }
    });
}

category.reset = function () {
    $('#CategoryName').val("");
    $('#CategoryId').val(0);
}

category.save = function () {
    var saveObj = {};
    saveObj.CategoryName = $('#CategoryName').val();
    saveObj.CategoryId = parseInt($('#CategoryId').val());
    $.ajax({
        url: `/Category/Save/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditCategory').modal('hide');
            bootbox.alert(data.result.message);
            category.drawTable();
        }
    });
}

category.init = function () {
    category.drawTable();
};

$(document).ready(function () {
    category.init();
});