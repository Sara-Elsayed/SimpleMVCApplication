function confirmDelete(id) {
    let res = confirm("Are you sure you want to Delete?");
    if (res) {
        var url = window.location.pathname.split("/");
        var currentController = url[1];
        $.ajax({
            url: `${currentController}/delete/${id}`,
            type: "GET",
        success: function (res) {
            if(res){
                $(`#${id}`).remove();
            }
        },
        error:function(err){
            console.log(err);
        }
    })
    }
}