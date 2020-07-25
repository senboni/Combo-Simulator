function getAllChases()
{
    let ninjas = []
    var causeCont = document.getElementById("cause-container")
    var mystCont = document.getElementById("mystery-container")
    var attCont = document.getElementById("attack-container")

    for(i = 1; i <= 9; i++)
    {
        let slot = document.getElementById(`pos-${i}`)
        if(slot && slot.lastChild && slot.lastChild.tagName == "IMG")
        {
            ninjas.push($(slot.lastChild).data("storedNinja"))
        }
    }

    if(causeCont.hasChildNodes) causeCont.innerHTML = ""
    //if(mystCont.hasChildNodes) mystCont.innerHTML = ""
    //if(attCont.hasChildNodes) attCont.innerHTML = ""

    ninjas.forEach(ninja => {
        var cause = document.createElement("div")
    
        cause.setAttribute("class", "cause")
        cause.setAttribute("id", `cause-${i}`)

        cause.style.background = `url(assets/ninjas/${ninja.imagePath}) no-repeat, linear-gradient(0deg, rgba(8,14,19,1) 0%, rgba(31,59,85,1) 100%)`

        cause.addEventListener("click", function(){
            var removeSelected = causeCont.getElementsByClassName("cause cause-selected")
            if(removeSelected[0]) removeSelected[0].className = "cause"
            cause.className = "cause cause-selected"

            if(mystCont.hasChildNodes) mystCont.innerHTML = ""
            if(attCont.hasChildNodes) attCont.innerHTML = ""
            insertChases(mystCont, ninja, `mysteries/${ninja.mystery.imagePath}`)
            insertChases(attCont, ninja, `attacks/${ninja.attack.imagePath}`)

            calculateCombo(ninjas, ninja.mystery.causing, "mystery")
            calculateCombo(ninjas, ninja.attack.causing, "attack")
        }, true)

        causeCont.insertAdjacentElement("beforeend", cause)
    });
}

function calculateCombo(ninjas, cause, type)
{
    var chaseCont = document.getElementById(`${type}-container`)
    const ninjaCopy = JSON.parse(JSON.stringify(ninjas))
    let repeat = 0

    ninjas.forEach(ninja => {
        ninja.chases.forEach(chase => {
            if(chase) repeat += chase.repeat
        })
    })

    for (i = 0; i < ninjas.length; i++) {
        ninjaCopy.forEach(ninja => {
            ninja.chases.forEach(chase => {
                if(chase){
                    if(chase.chasing == cause && chase.repeat > 0){
                        insertChases(chaseCont, ninja, `chases/${chase.imagePath}`)
                        chase.repeat--
                        cause = chase.causing
                    }
                    else if(chase.repeat > 0){
                        repeat--
                    }
                }
            })
        })
    }
}

function insertChases(chaseCont, ninja, path){
    let chaseDiv = document.createElement("div")
    let chaseImg = document.createElement("img")

    chaseDiv.className = "chase"
    chaseDiv.style.background = `Url(/assets/ninjas/${ninja.imagePath}) no-repeat`
    chaseImg.src = `assets/${path}`

    chaseDiv.insertAdjacentElement("beforeend", chaseImg)
    chaseCont.insertAdjacentElement("beforeend", chaseDiv)
}

// function getAllChases()
// {
//     let chaseArray = []

//     for(i = 1; i <= 9; i++)
//     {
//         let slot = document.getElementById(`pos-${i}`)
//         if(slot && slot.lastChild && slot.lastChild.tagName == "IMG")
//         {
//             chaseArray.push($(slot.lastChild).data("storedNinja"))
//         }
//     }
    
//     calculateCombo(chaseArray)
// }

// function calculateCombo(ninjas)
// {
//     const ninjaCopy = JSON.parse(JSON.stringify(ninjas))

//     let cause = "Repulse"
//     let repeat = 0
//     let comboSuccess = []

//     ninjaCopy.forEach(ninja => {
//         ninja.chases.forEach(chase => {
//             if(chase) repeat += chase.repeat
//         })
//     })

//     while(repeat > 0){
//         ninjaCopy.forEach(ninja => {
//             ninja.chases.forEach(chase => {
//                 if(chase && chase.chasing == cause && chase.repeat > 0){
//                     comboSuccess.push(chase)
//                     chase.repeat--
//                     cause = chase.causing
//                 }
//                 if(chase && chase.repeat < 1) repeat--
//             })
//         })
//     }

//     console.log(comboSuccess)
// }