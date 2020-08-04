var publishing = {} || publishing;

publishing.drawTable = function () {
    $.ajax({
        url: "/Publishing/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbPublishing tbody').empty();
            $.each(data.publishings, function (i, v) {
                $('#tbPublishing tbody').append(
                    `<tr>
                        <td>${v.publishingId}</td>
                        <td>${v.publishingName}</td>
                        <td><a href="/Book/Index/${v.publishingId}" title="Book list">${v.soluongSach}</a></td>
                        <td>
                            <a href="javascripts:;"
                                       onclick="category.get(${v.publishingId})"><i class="fas fa-edit"></i></a> 
                            <a href="javascripts:;" class="item"
                                       onclick="category.delete(${v.publishingId})"><i class="zmdi zmdi-delete"></i></a>
                        </td>
                    </tr>`
                );
            });
        }
    });

};

publishing.openAddEditPublishing = function () {
    publishing.reset();
    $('#addEditPublishing').appendTo("body").modal('show');
};


publishing.delete = function (id) {
    bootbox.confirm({
        title: "Delete punlishing?",
        message: "Do you want to delete this publishing.",
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
                    url: `/Publishing/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.result.message);
                        publishing.drawTable();
                    }
                });
            }
        }
    });
}


publishing.get = function (id) {
    $.ajax({
        url: `/Publishing/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#PublishingName').val(data.result.publishingName);
            $('#PublishingId').val(data.result.publishingId);
            $('#addEditPublishing').modal('show');
        }
    });
}

publishing.reset = function () {
    $('#PublishingName').val("");
    $('#PublishingId').val(0);
}

publishing.save = function () {
    var saveObj = {};
    saveObj.PublishingName = $('#PublishingName').val();
    saveObj.PublishingId = parseInt($('#PublishingId').val());
    $.ajax({
        url: `/Publishing/Save/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditPublishing').modal('hide');
            bootbox.alert(data.result.message);
            publishing.drawTable();
        }
    });
}

publishing.init = function () {
    publishing.drawTable();
};

$(document).ready(function () {
    publishing.init();
});