const Title_form_informations = document.querySelector(".title-infomations");
const form_content = document.querySelector(".form-content");
const hours_header = document.querySelector(".hours-header");
const tl = new TimelineMax();

tl.fromTo(Title_form_informations,1,{opacity:0, x:80},{opacity:1 ,x:0}, "-=0.1");
tl.fromTo(form_content,1,{opacity:0, y:80},{opacity:1 ,y:0}, "-=0.5");
tl.fromTo(hours_header,1,{height:100},{height:20}, "-=0.1");
