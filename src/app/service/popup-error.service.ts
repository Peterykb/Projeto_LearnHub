import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PopupErrorService {

  message = ''
  constructor() { }

  addMessage(message: string){
    this.message = message
    setTimeout(()=>{
      this.clear()
    },4000)
  }

  canShow: boolean = false

  clear(){
    this.message = ''
  }

  openPopup(){
    this.canShow = true
  }
}
