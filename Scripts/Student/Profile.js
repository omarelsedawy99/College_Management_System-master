function EditData() {
    if (document.getElementById('EditBtn').textContent == "Cancel") {
        document.getElementById('phone').classList = "form-control inputClass";
        document.getElementById('email').classList = "form-control inputClass";
        document.getElementById('password').classList = "form-control inputClass";
        document.getElementById('street').classList = "form-control inputClass";
        document.getElementById('city').classList = "form-control inputClass";
        document.getElementById('country').classList = "form-control inputClass";

        document.getElementById('profileImg').value = "";
        document.getElementById('EditBtn').textContent = "Edit";
        document.getElementById('SaveBtn').style.visibility = "hidden";
    }
    else {
        document.getElementById('phone').classList = "form-control";
        document.getElementById('email').classList = "form-control";
        document.getElementById('password').classList = "form-control";
        document.getElementById('street').classList = "form-control";
        document.getElementById('city').classList = "form-control";
        document.getElementById('country').classList = "form-control";

        document.getElementById('EditBtn').textContent = "Cancel";
        document.getElementById('SaveBtn').style.visibility = "visible";
    }
}

function UploadImg() {
    document.getElementById('EditBtn').textContent = "Cancel";
    document.getElementById('SaveBtn').style.visibility = "visible";
}

function DeleteImg() {
    document.getElementById('deleteImg').value = "true";
}