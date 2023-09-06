var flag;
function formEdit() {
    flag = false;
    document.getElementById("submitBtn").style.display = "inline";
    document.getElementById("DOB").classList.remove("inputClass");
    document.getElementById("city").classList.remove("inputClass");
    document.getElementById("district").classList.remove("inputClass");
    document.getElementById("street").classList.remove("inputClass");
}
function formSubmit() {
    flag = true;
}
function onSubmit() {
    return flag;
}