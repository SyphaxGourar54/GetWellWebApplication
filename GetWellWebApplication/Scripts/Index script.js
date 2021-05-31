const nom = document.querySelector('#nom');
const prenom = document.querySelector("#prenom");
const cin = document.querySelector('#CIN');
const datenaissance = document.querySelector("#dnaissance");
const tel = document.querySelector("#tel");
const email = document.querySelector("#email");
const description = document.querySelector("#Description");
const suivant = document.querySelector('#Suivant');


suivant.addEventListener('click',function verfyingName() {
    const formatmessage = document.querySelector('.formatmerssage');
    let messageeparagraph = document.createElement('p');
    let messageicon = document.createElement('i');
    formatmessage.classList.add("fas", "fa-exclamation-circle");
    if(formatmessage.childElementCount != 0){
        while(formatmessage.firstChild){
            formatmessage.removeChild(formatmessage.firstChild);
        }
    }
    if(verifyFullyTyped()){
        formatmessage.append("    Vous dever remplire tout les champs", messageeparagraph);
        formatmessage.append(messageicon);
    }
    else if(verifyFormat()){
        formatmessage.append("    Format d'un champ est invalide", messageeparagraph);
        formatmessage.append(messageicon);
    }else{
        window.location.href = "http://127.0.0.1:5500/Rendzevous_jour.html";
    }
});

function verifyFullyTyped() {
    if(nom.value == ""||prenom.value == "" ||cin.value==""||tel.value == ""||email.value == ""){
        return true;
    }
    else{
        return false;
    }
}

function verifyFormat() {
    var nomformat = /^[A-Za-z]+$/;
    var telformat = /^[\+]?\d{2,}?[(]?\d{2,}[)]?[-\s\.]?\d{2,}?[-\s\.]?\d{2,}[-\s\.]?\d{0,9}$/im;
    var emailformat = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if(!nom.value.match(nomformat) || !prenom.value.match(nomformat) || !email.value.match(emailformat) || !tel.value.match(telformat)){
        return true;
    }
    else{
        return false;
    }
}