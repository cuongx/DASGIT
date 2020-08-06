var book = {} || book;
var id = 0;
book.drawTable = function () {
    $.ajax({
        url: `/Book/Gets/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbBooks tbody').empty();
            $.each(data.books, function (i, v) {
                $('#tbBooks tbody').append(
                    `<tr>
                        <td>${v.id}</td>                                   
                         <td>${v.bookName}</td>
                         <td><img src='${v.avatar}' width='80' height='90'/></td>
                            <td>${v.updateDay}</td>
                             <td>${v.authorId}</td>
                               <td>${v.categoryId}</td>
                                 <td>${v.publishingId}</td>
                                    <td>${v.description}</td>                                    
                                   <td>
                                        <a href="javascripts:;" 
                                            onclick="book.get(${v.id})"><i class="fas fa-edit"></i></a> 
                                        <a href="javascripts:;" class="item"
                                        onclick="book.delete(${v.id})"><i class="zmdi zmdi-delete"></i></a>
                                 </td>
                           </tr>`
                );
            });
        }
    });

};

book.openAddEditBook = function () {
     book.reset();
    $('#addEditBooks').appendTo("body").modal('show');
};


book.delete = function (id) {
    bootbox.confirm({
        title: "Delete Books?",
        message: "Do you want to delete this Books.",
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
                    url: `/Book/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.result.message);
                        book.drawTable();
                    }
                });
            }
        }
    });
}

book.uploadAvatar = function (input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#Avatar').attr('src', e.target.result);
            $('#img').append(`<input type="text" hidden value="${e.target.result}" id="avatar"/>`);
        };
        reader.readAsDataURL(input.files[0]);
    }
}


book.get = function (id) {
    $.ajax({
        url: `/Book/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {          
            $('#Id').val(data.result.id);
            $('#BookName').val(data.result.bookName);
            $('#DayTime').val(convert(data.result.updateDay));
            $('#Author').val(data.result.authorId);
            $('#Publishing').val(data.result.publishingId);
            $('#Avatar').attr('src',data.result.avatar);
            $('#Description').val(data.result.description)
            $('#addEditBooks').find('.modal-title').text('Edit Books')
            $('#addEditBooks').modal('show');
        }
    });
}

book.reset = function () {
    $('#BookName').val("");
    $('#Id').val(0);
    $('#DayTime').val("");
    $('#Author').val("");
    $('#Publishing').val(0);
    $('#Category').val(0);
    $('#Avatar').attr('src', '/images/logo.png')
    $('#Description').val("")
    $('#IsDeleted').val(0);
    $('#addEditBooks').find('.modal-title').text('Add New Books');
};

book.save = function () {
    var saveObj = {};
    saveObj.BookName = $('#BookName').val();
    saveObj.Id = parseInt($('#Id').val());
    saveObj.CategoryId = parseInt($('#Category').val());
    saveObj.Description = $('#Description').val();
    saveObj.Updateday = $('#DayTime').val();
    saveObj.PublishingId = parseInt($('#Publishing').val());
    saveObj.AuthorId = parseInt($('#Author').val());
    saveObj.Avatar = $('#Avatar').attr('src');
    $.ajax({
        url: `/Book/Save/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data:JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditBooks').modal('hide');
            bootbox.alert(data.result.message);
            book.drawTable();
        }
    });
}

book.initCategory = function () {
    $.ajax({
        url: "/Category/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {          
            $('#Category').empty();
            $.each(data.categorys, function (i, v) {           
                $('#Category').append(`<option value="${v.categoryId}">${v.categoryName}</option>`)
            });
        }
    });
}
book.initPublishing = function () {
    $.ajax({
        url: "/Publishing/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {        
            $('#Publishing').empty();
            $.each(data.publishings, function (i, v) {          
                $('#Publishing').append(`<option value="${v.publishingId}">${v.publishingName}</option>`)
            });
        }
    });
}
book.initAuthor = function () {
    $.ajax({
        url: "/Author/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {  
            $('#Author').empty();
            $.each(data.authors, function (i, v) {
                $('#Author').append(`<option value="${v.authorId}">${v.authorName}</option>`)
            });
        }
    });
}
book.init = function () {
    book.drawTable();
    book.initCategory();
    book.initPublishing();
    book.initAuthor();
};

$(document).ready(function () {
    id = $("#CategoryId").val();
    book.init();
});