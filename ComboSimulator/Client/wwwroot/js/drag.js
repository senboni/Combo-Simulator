function nClicked(ninja, e, chases, passives, slot) 
{
    document.body.style.overflow = "hidden";

    const cont = document.getElementById("mainContainer");
    const moveset = document.createElement("img");
    const glow = document.createElement("div");

    // moveset style
    moveset.hidden = true;
    moveset.setAttribute("id", `${ninja.id}`);
    moveset.setAttribute("class","moveset noselect");
    moveset.setAttribute("src", `assets/ninjas/moveset/${ninja.imagePath}`);

    if(slot != undefined) moveset.setAttribute("data-slot", `${slot}`);

    moveset.draggable = false;
    moveset.style.overflow = "hidden";
    moveset.style.cursor = "grabbing";
    
    let offset = moveset.width/2;
    let posY = e.clientY-150;
    let posX = e.clientX-offset;
    moveset.style.top = `${posY}px`;
    moveset.style.left = `${posX}px`;

    if(!chases && !passives){
        $(moveset).data("storedNinja", ninja)
    }else{        
        ninja["chases"] = chases
        ninja["passives"] = passives
        $(moveset).data("storedNinja", ninja)
    }

    // glow style
    glow.hidden = true;
    glow.setAttribute("class", "glowing noselect glow-red");
    glow.draggable = false;
    glow.overflow = "hidden";
    glow.style.top = `${posY+120}px`;
    glow.style.left = `${posX-20}px`;
    
    // insert in body
    cont.insertAdjacentElement("beforeend", glow);
    cont.insertAdjacentElement("beforeend", moveset);

    glow.hidden = false;
    moveset.hidden = false;

    // dragging
    var moveMoveset = function(event)
    {
        // moveset drag
        let offseta = moveset.width/2;
        let posYa = event.clientY-150;
        let posXa = event.clientX-offseta;

        moveset.style.top = `${posYa}px`;
        moveset.style.left = `${posXa}px`;

        // glow snap
        const elemsBelow = document.elementsFromPoint(event.clientX, event.clientY);

        const elemDroppable = elemsBelow.find(function(e){
            return e.classList.contains("droppable");
        });

        const elemMoveset = elemsBelow.find(function(e){
            return e.tagName.match("IMG") && e.parentElement.classList.contains("droppable");
        });

        if(elemMoveset)
        {
            var element = elemMoveset.parentElement;
            glowSnap(element, glow);
        }
        else if(elemDroppable)
        {
            glowSnap(elemDroppable, glow);
        }
        else
        {
            glow.setAttribute("class", "glowing noselect glow-red");
            glow.style.top = `${posYa+120}px`;
            glow.style.left = `${posXa-20}px`;
        }
    }

    cont.addEventListener("mousemove", moveMoveset, true);

    // dropping
    var dropMoveset = function(e)
    {
        glow.remove();
        moveset.remove();
        cont.removeEventListener("mousemove", moveMoveset, true);
        getAllChases();

        const elemsBelow = document.elementsFromPoint(e.clientX, e.clientY);
        const elemMoveset = elemsBelow.find(function(e){
            return e.tagName.match("IMG");
        });
        const elemGlow = elemsBelow.find(function(e){
            return e.classList.contains("glowing");
        });

        if(elemMoveset)
        {
            var glw = elemMoveset.parentElement.firstChild;
            movesetDrop(ninja, elemMoveset, glw, slot);
        } 
        else if(elemGlow)
        {
            var mset = elemGlow.parentElement.lastChild;
            movesetDrop(ninja, mset, elemGlow, slot);
        }
        else
        {
            eachSlot(e, ninja);
        }

        document.body.style.overflow = "visible";
    }

    moveset.addEventListener("mouseup", dropMoveset, true);
    glow.addEventListener("mouseup", dropMoveset, true);
}

function createOnfield(ninja, pos)
{
    const onfield = document.createElement('img');
    const glow = document.createElement("div");
    const droppable = document.querySelector(`#${pos}`);

    // onfield style (moveset)
    onfield.setAttribute("id", `${ninja.id}`);
    onfield.setAttribute("src", `assets/ninjas/moveset/${ninja.imagePath}`);
    onfield.setAttribute("data-slot", `${pos}`);

    if(onfield.width > 200) onfield.style.left = `${0 - onfield.width/4}px`;
    else onfield.style.left = 0;

    onfield.draggable = false;

    $(onfield).data("storedNinja", ninja);

    // glow style
    glow.setAttribute("class", "glowing noselect glow-blue");

    if(droppable.classList.contains("center-row")) glow.style.top = "10px", onfield.style.marginTop = "-120px";
    if(droppable.classList.contains("bottom-row")) glow.style.top = "20px", onfield.style.marginTop = "-110px";

    glow.draggable = false;

    // insert in slot
    droppable.insertAdjacentElement("beforeend", glow);
    droppable.insertAdjacentElement("beforeend", onfield);

    getAllChases();

    onfield.addEventListener("mousedown", e => nPickedUp(onfield, onfield.parentElement, ninja, e));
}

function nPickedUp(element, parentElement, ninja, e){
    parentElement.innerHTML = "";
    nClicked(ninja, e, undefined, undefined, element.getAttribute('data-slot'));
}

function eachSlot(e, ninja){
    const elemBelow = document.elementFromPoint(e.clientX, e.clientY);

    switch (elemBelow.id) {
        case "pos-1": createOnfield(ninja, "pos-1"); break;
        case "pos-2": createOnfield(ninja, "pos-2"); break;
        case "pos-3": createOnfield(ninja, "pos-3"); break;
        case "pos-4": createOnfield(ninja, "pos-4"); break;
        case "pos-5": createOnfield(ninja, "pos-5"); break;
        case "pos-6": createOnfield(ninja, "pos-6"); break;
        case "pos-7": createOnfield(ninja, "pos-7"); break;
        case "pos-8": createOnfield(ninja, "pos-8"); break;
        case "pos-9": createOnfield(ninja, "pos-9"); break;
        default: break;
      }
}

function glowSnap(element, glow){
    var rect = element.getBoundingClientRect();
    glow.style.top = `${rect.top}px`;
    glow.style.left = `${rect.left}px`;

    if(element.classList.contains("center-row")) glow.style.top = `${rect.top+10}px`;
    if(element.classList.contains("bottom-row")) glow.style.top = `${rect.top+20}px`;

    glow.setAttribute("class", "glowing noselect glow-green");
}

function movesetDrop(ninja, moveset, glow, slot)
{
    if(slot)
    {
        createOnfield(ninja, moveset.getAttribute('data-slot'));
        moveset.setAttribute("data-slot", `${slot}`);        
        $(glow).appendTo(document.getElementById(slot));
        $(moveset).appendTo(document.getElementById(slot));
    }
    else
    {
        createOnfield(ninja, moveset.getAttribute('data-slot'));
        glow.remove();
        moveset.remove();
    }
}