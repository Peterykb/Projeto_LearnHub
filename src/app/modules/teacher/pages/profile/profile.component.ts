import { Component, ElementRef, QueryList, ViewChildren } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  canEdit: boolean = false;
  imageUrl: string | ArrayBuffer | null = null;

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

  cancelEdit() {
    this.canEdit = !this.canEdit;
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.imageUrl = URL.createObjectURL(file); 
    }
  }
}
