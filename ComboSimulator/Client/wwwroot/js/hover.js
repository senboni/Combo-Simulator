function notHovered(ninRef){
    const hoverCont = document.getElementById("hover-id")
    
    if(hoverCont)
    {   
        document.body.style.overflow = "visible"
        hoverCont.remove()
    }
}

function nHovered(ninja, chases, passives)
{
    const exists = document.getElementById("hover-id")

    if(!exists)
    {
        document.body.style.overflow = "hidden"
        const cont = document.getElementById("mainContainer")

        const hoverCont = document.createElement("div")
        const hr = document.createElement("hr")
        hr.setAttribute("class", "hover-hr")


        var rect = document.getElementById("ninjas-container-id").getBoundingClientRect();
        leftX = rect.left;

        // hover conatiner
        hoverCont.setAttribute("id", "hover-id")
        hoverCont.setAttribute("class", "hover-container")
        hoverCont.style.left = `${leftX-500}px`

        if(ninja.mystery)
        {
            insertSkill(ninja.mystery, hoverCont, "mysteries")
            hoverCont.insertAdjacentElement("beforeend", hr)
        }
        if(ninja.attack)
        {
            insertSkill(ninja.attack, hoverCont, "attacks")
            hoverCont.insertAdjacentElement("beforeend", hr.cloneNode())
        }
        if(chases[0])
        {
            insertSkill(chases[0], hoverCont, "chases")
            hoverCont.insertAdjacentElement("beforeend", hr.cloneNode())
        }
        if(chases[1])
        {
            insertSkill(chases[1], hoverCont, "chases")
            hoverCont.insertAdjacentElement("beforeend", hr.cloneNode())
        }
        if(chases[2])
        {
            insertSkill(chases[2], hoverCont, "chases")
            hoverCont.insertAdjacentElement("beforeend", hr.cloneNode())
        }
        if(passives[0])
        {
            insertSkill(passives[0], hoverCont, "passives")
            hoverCont.insertAdjacentElement("beforeend", hr.cloneNode())
        }
        if(passives[1])
        {
            insertSkill(passives[1], hoverCont, "passives")
            hoverCont.insertAdjacentElement("beforeend", hr.cloneNode())
        }
        if(passives[2])
        {
            insertSkill(passives[2], hoverCont, "passives")
            hoverCont.insertAdjacentElement("beforeend", hr.cloneNode())
        }

        hoverCont.lastChild.remove();

        // insert
        document.body.insertAdjacentElement("beforeend", hoverCont)  
    }
    
}

function insertSkill(skill, cont, ipath)
{
    const infoMystery = document.createElement("div")
    infoMystery.setAttribute("class", "hover-info")

    const imImg = document.createElement("img")
    imImg.alt = ""
    imImg.src = `assets/${ipath}/${skill.imagePath}`
    infoMystery.insertAdjacentElement("beforeend", imImg)

    const imSpan = document.createElement("span")
    imSpan.innerHTML = `${skill.description}`
    infoMystery.insertAdjacentElement("beforeend", imSpan)

    const imName = document.createElement("span")
    imName.innerHTML = `${skill.name}`
    imSpan.insertAdjacentElement("afterbegin", imName)

    const imJutsu = document.createElement("div")

    if(skill.jutsu1){
        const imjOne = document.createElement("img")
        imjOne.alt = ""
        imjOne.src = `assets/attributes/${skill.jutsu1}.png`
        imJutsu.insertAdjacentElement("beforeend", imjOne)
    }
    if(skill.jutsu2){
        const imjTwo = document.createElement("img")
        imjTwo.alt = ""
        imjTwo.src = `assets/attributes/${skill.jutsu2}.png`
        imJutsu.insertAdjacentElement("beforeend", imjTwo)
    }

    infoMystery.insertAdjacentElement("beforeend", imJutsu)

    const imAtt = document.createElement("div")

    if(skill.attribute1){
        const imaOne = document.createElement("img")
        imaOne.alt = ""
        imaOne.src = `assets/attributes/${skill.attribute1}.png`
        imAtt.insertAdjacentElement("beforeend", imaOne)
    }
    if(skill.attribute2){
        const imaTwo = document.createElement("img")
        imaTwo.alt = ""
        imaTwo.src = `assets/attributes/${skill.attribute2}.png`
        imAtt.insertAdjacentElement("beforeend", imaTwo)
    }
    
    infoMystery.insertAdjacentElement("beforeend", imAtt)

    cont.insertAdjacentElement("beforeend", infoMystery)
}