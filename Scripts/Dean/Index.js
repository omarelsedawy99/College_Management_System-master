$("#employee").click(function(){
    $("#Employee-form").toggle(1000);
    $("#Student-form").css("display","none");
    $("#Professor-form").css("display","none");
});
$("#student").click(function(){
    $("#Student-form").toggle(1000);
    $("#Employee-form").css("display","none");
    $("#Professor-form").css("display","none");
});
$("#professor").click(function(){
    $("#Professor-form").toggle(1000);
    $("#Student-form").css("display","none");
    $("#Employee-form").css("display","none");
});
let myText=$("#productDesc").attr("maxlength");
$(".countChar").html('<span>'+myText+'</span> Characters Remaining');
$("textarea").keyup(function(){
    let textLength=$(this).val().trim().length;
    let remText=myText-textLength;
    console.log(remText);
    $(".countChar").html('<span>'+remText+'</span> Characters Remaining');
});