import { Component, OnInit } from '@angular/core';
import { PopupErrorService } from 'src/app/service/popup-error.service';

@Component({
  selector: 'app-popup-error',
  templateUrl: './popup-error.component.html',
  styleUrls: ['./popup-error.component.scss']
})
export class PopupErrorComponent implements OnInit{

  constructor(public popupService: PopupErrorService){}
  ngOnInit(): void {

  }
}
