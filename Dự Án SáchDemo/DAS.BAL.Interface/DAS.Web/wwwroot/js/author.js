var author = {} || author;

author.drawTable = function () {
    $.ajax({
        url: "/Author/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbAuthor tbody').empty();
            $.each(data.authors, function (i, v) {
                $('#tbAuthor tbody').append(
                    `<tr>
                        <td>${v.authorId}</td>
                        <td>${v.authorName}</td>
                        <td>${v.avatarPath}</td>
                        <td><a href="/Book/Index/${v.authorId}" title="Author list">${v.soluongSach}</a></td>
                        <td>
                            <a href="javascripts:;"
                                       onclick="author.get(${v.authorId})"><i class="fas fa-edit"></i></a> 
                            <a href="javascripts:;" class="item"
                                        onclick="author.delete(${v.authorId})"><i class="zmdi zmdi-delete"></i></a>
                        </td>
                    </tr>`
                );
            });
        }
    });

};

author.openAddEditAuthor = function () {
    author.reset();
    $('#addEditAuthor').appendTo("body").modal('show');
};


author.delete = function (id) {
    bootbox.confirm({
        title: "Delete author?",
        message: "Do you want to delete this author.",
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
                    url: `/Author/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.result.message);
                        author.drawTable();
                    }
                });
            }
        }
    });
}


author.get = function (id) {
    $.ajax({
        url: `/Author/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#AuthorName').val(data.result.authorName);
            $('#AuthorId').val(data.result.authorId);
            $('#AvatarPath').val(data.result.avatar);
            $('#addEditAuthor').modal('show');
        }
    });
}


author.uploadAvatar = function (input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#AvatarPath').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}



author.reset = function () {
    $('#AuthorId').val(0);
    $('#AuthorName').val("");
    $('#AvatarPath').val("");
}

author.save = function () {
    var saveObj = {};
    saveObj.AuthorName = $('#AuthorName').val();
    saveObj.AuthorId = parseInt($('#AuthorId').val());
    saveObj.Avatar = parseInt($('#AvatarPath').val());
    $.ajax({
        url: `/Author/Save/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditAuthor').modal('hide');
            bootbox.alert(data.result.message);
            author.drawTable();
        }
    });
}

author.init = function () {

    author.drawTable();
};

$(document).ready(function () {
    //id = $("AuthorId").val();
    author.init();
});