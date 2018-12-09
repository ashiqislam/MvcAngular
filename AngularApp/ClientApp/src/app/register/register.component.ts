import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { Form } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model = new User();
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  submit(form: Form) {
    console.log('Submitted');

    console.log(this.model)
    console.log(form);
    if (this.model['password'] == this.model['confirmpassword']) {
      console.log("Password Match!");
      alert("Success!");
    } else {
      console.log("Passwords doesn't Match!");
      alert("Sorry! Passwords must match.");
    }
  }
}
