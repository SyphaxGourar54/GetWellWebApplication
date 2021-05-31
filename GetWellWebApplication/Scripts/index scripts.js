const Title_index = document.querySelector(".Index-title");
const prgrss = document.querySelector(".prgrss");
const sub_title = document.querySelector(".sub-title");
const image = document.querySelector(".doctor-img1");
const sub_image = document.querySelector(".doctor-name");
const tl = new TimelineMax();
tl.fromTo(Title_index,1,{opacity:0, x:80},{opacity:1 ,x:0}, "-=0.5");
tl.fromTo(prgrss,1,{width:0,opacity:1},{width:200,opacity:0.3}, "-=0.3");
tl.fromTo(sub_title,1,{opacity:0, x:30},{opacity:1 ,x:0}, "-=0.5");
tl.fromTo(image,1,{opacity:0, x:-30},{opacity:1 ,x:0}, "-=0.5");
tl.fromTo(sub_image,1,{opacity:0},{opacity:1}, "-=0.5");



const api_url = '/home/GetAllLocation';

async function getISS() {
    const response = await fetch(api_url);
    const data = await response.json();
    const { latitude, longitude } = data;
    const map = L.map('map').setView([latitude, longitude], 13);
    const attribution = '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'

    const tileUrl = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
    const tiles  = L.tileLayer(tileUrl, { attribution });
    tiles.addTo(map);

var GetWellIcon = L.icon({
    iconUrl: 'images/Logo.png',
    iconSize: [38, 35],
    iconAnchor: [25, 16],
    popupAnchor: [-3, -76],
    shadowSize: [68, 95],
    shadowAnchor: [22, 94]
});

    const marker = L.marker([latitude, longitude], {icon: GetWellIcon}).addTo(map);
    
}

getISS()


