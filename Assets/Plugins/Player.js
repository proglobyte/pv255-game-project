#pragma strict

var id : String;
var maxEnergy : int = 10;
var energy : int = 0;
var lap : int = 1;
var checkpoint : int = 0;
var requiredEnergyEmp : int = 5;
var requiredEnergyMissile : int = 7;
var requiredEnergyLaser : int = 1;
var canEmp : boolean = false;
var canMissile : boolean  = false;
var canLaser : boolean = false;
var power : int = 50;
var win : int=0;
function addEnergy(amount : int){
  energy += amount;
  if(energy > maxEnergy){
    energy = maxEnergy;
  }

  if(energy >= requiredEnergyEmp){
    canEmp = true;
  }
  if(energy >= requiredEnergyLaser){
    canLaser = true;
  }
  if(energy >= requiredEnergyMissile){
    canMissile = true;
  }
}

function isFull(){
	return energy == maxEnergy;
}

function addLap(amount : int){
  lap += amount;
  
  }
function removeEnergy(amount : int){
  if(amount > energy){
    energy = 0;
  }else{
    energy -= amount;
  }

  if(energy < requiredEnergyEmp){
    canEmp = false;
  }
  if(energy < requiredEnergyLaser){
    canLaser = false;
  }
  if(energy < requiredEnergyMissile){
    canMissile = false;
  }
}

function shotMissile(){
  removeEnergy(requiredEnergyMissile);
}

function shotLaser(){
  removeEnergy(requiredEnergyLaser);
}

function shotEmp(){
  removeEnergy(requiredEnergyEmp);
}
