import { Component, ElementRef, ViewChildren, QueryList } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss'],
})
export class MyProfileComponent {
  constructor( private auth: AuthService) {}

  canEdit: boolean = false;

  @ViewChildren('inputContainer') inputContainers!: QueryList<ElementRef>;

  habilitEdit() {
    if (!this.canEdit) {
      this.inputContainers.forEach((container) => {
        const inputElement = container.nativeElement.querySelector('input');
        this.canEdit = true;
        inputElement.setAttribute('disabled', 'false');
      });
    }
  }

  logout(){
    this.auth.logout()
  }

  cancelEdit() {
    this.canEdit = !this.canEdit;
  }
}
