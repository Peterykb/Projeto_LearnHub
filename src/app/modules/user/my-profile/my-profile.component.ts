import { Component, ElementRef, ViewChildren, QueryList } from '@angular/core';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent {

  canEdit: boolean = false;

  @ViewChildren('inputContainer') inputContainers!: QueryList<ElementRef>;

  habilitEdit() {
    if (!this.canEdit) {
      this.inputContainers.forEach(container => {
        const inputElement = container.nativeElement.querySelector('input');
        this.canEdit = true
        inputElement.setAttribute('disabled', 'false');
      });
    }
  }

  cancelEdit(){
    this.canEdit = !this.canEdit
  }

}
