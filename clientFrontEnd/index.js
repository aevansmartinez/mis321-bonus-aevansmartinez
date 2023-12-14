let count = 0;
let myCars = [];
const url = 'http://localhost:5003/api/Car';

async function handleOnLoad(){
    let response = await fetch(url);
    let data = await response.json();
    myCars = data;
    if(!myCars){myCars = []}
    
    let html= `      
    <div class="grid-container ">
            <div class="logo1 ">
                <img src="images/KiaLogo.png" height="100" width="273">
            </div>
            <div class="navbar navbarbutton centered-text">
                  <a>Shop New</a>
                  <a>Sell/Trade</a>
                  <a>Service & Parts</a>
                  <a>About Us</a>
                
                <div class="search"> <div class = "searchbox">
                  <a>search&#32&#x1F50E</a>
                </div> </div>         
            </div>
          </div>
    
    <div class="banner">
        <h1>Julio Jones Kia</h1>
    </div>

    <div id='tableBody'></div>
    
    <form onsubmit= "return false">
            <label for="make">Make:</label><br>
            <input type="text" id="make" name="make"><br>

            <label for="model">Model:</label><br>
            <input type="text" id="model" name="model"><br>

            <label for="mileage">Mileage:</label><br>
            <input type="text" id="mileage" name="mileage"><br>

            <button onclick="PostCar()" class="btn btn-hold">Add Car</button>
    </form>`;
    document.getElementById('app').innerHTML=html;
    populateTable();
}
async function PostCar(){ //adds car to table ~~~~~~~~~~~~~~~~~~~~~~~~ DONE
    const makeConst = document.getElementById('make').value;
    const modelConst = document.getElementById('model').value;
    const mileageConst = document.getElementById('mileage').value;

    let car = {
        id: 0,
        make: makeConst,
        model: modelConst,
        mileage: mileageConst,
        hold: false,
        deleted: false,
      };

    let carID = await fetch (url, {
        method: "POST",
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify(car),
        });
        
    car.id = await carID.json();
    myCars.push(car);
    populateTable();
}
async function PutCar(myCar){ //hold or delete an car ~~~~~~ DONE
    let newUrl = url + "/" + myCar.id;
    await fetch (newUrl, {
        method: "PUT",
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify(myCar),
        });
    populateTable();
}
function SortArray(){
    myCars.sort(function (a,b){
        if (a.hold != b.hold){
            if (a.hold == true) return 1;
            else return -1;
        }
        if (a.id < b.id) return -1;
        else return 1;
    });
}
async function handleCarDeleteSoft(id){ //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ DONE
    let tempCar = myCars.find(function (a){
        return a.id == id;
    });
    tempCar.deleted = !tempCar.deleted;
    await PutCar(tempCar);
}
async function handleCarHold(findId){  //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ DONE
    let tempCar = myCars.find(function (a){
        return a.id == findId;
    });
    tempCar.hold = !tempCar.hold;
    await PutCar(tempCar);
}
function populateTable(){
    let html = `
    <table class="table table-striped">
            <tr>
                <th>Make</th>
                <th>Model</th>
                <th>Mileage</th>
                <th>Hold</th>
                <th>Delete</th>
            </tr>`;
    SortArray();
    myCars.forEach(function(car){
        let holdButton = "Unhold"
        if (car.mileage==undefined){
            car.mileage = 0;
        }
        if (car.hold == false){
            holdButton = "Hold";
        }
        if (car.deleted == false){
            html += `
                <tr>
                    <td>${car.make}</td>
                    <td>${car.model}</td>
                    <td>${car.mileage}</td>
                    <td><button class="btn btn-hold" onclick="handleCarHold('${car.id}')">${holdButton}</button></td>
                    <td><button class="btn btn-delete" onclick="handleCarDeleteSoft('${car.id}')">Delete</button></td>
                </tr>`;
        }
    })
    html += `</table>`
    document.getElementById('tableBody').innerHTML = html;
}