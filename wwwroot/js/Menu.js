"use strict";

const personalAccount = document.querySelector('#pa');

const topStripePa = document.querySelector('#div_pa');
let clop = false;
personalAccount.addEventListener('click', () => {
    if(!clop){
        clop = true;
        topStripePa.style.display = "flex";
    } else {
        clop = false;
        topStripePa.style.display = "none";
    }
})