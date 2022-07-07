import { AfterViewInit, Component, OnInit } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.css'],
})
export class PasswordComponent implements OnInit {
  result: string = '';
  error: any;
  constructor() {}

  ngOnInit() {
    let res: any;

    try {
      let password = prompt('enter password') || 'null';
      res = jwt_decode(password);
    } catch (e) {
      this.error = e;
    }

    this.result = res.code;
  }
}
