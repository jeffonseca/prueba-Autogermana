import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @ViewChild('loginForm', { static: false }) loginForm: NgForm | null = null;

  constructor(private http: HttpClient,private router: Router) {}

  login() {
    if (!this.loginForm) {
      return;
    }

    const formData = {
      user: this.loginForm.value.username,
      password: this.loginForm.value.password
    };
    console.log(formData)
    this.http.post<any>('https://localhost:7064/api/Auth/login', formData)
      .subscribe(
        response => {
          // Manejar la respuesta exitosa aquí
          console.log('Token de acceso:', response);
          if(response != undefined){
            console.log(response.isValidCredentials)
            localStorage.setItem('token', JSON.stringify(response.isValidCredentials));
            this.router.navigate(['dashboard']);
          }
        },
        error => {
          // Manejar el error aquí
          console.error('Error al iniciar sesión:', error);
        }
      );
  }
}