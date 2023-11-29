import { Component } from '@angular/core';

@Component({
  selector: 'app-change-pass',
  templateUrl: './change-pass.component.html',
  styleUrls: ['./change-pass.component.scss']
})
export class ChangePassComponent {
    oldPass = false;
    newPass = false;
    confirmNewPass = false;

    showOldPass(){
      this.oldPass = !this.oldPass
    }

    showNewPass(){
      this.newPass = !this.newPass
    }

    showConfirmNewPass(){
      this.confirmNewPass = !this.confirmNewPass
    }
}
