import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  transacciones: any[] = [];
  token: string | null = null;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    if (typeof localStorage !== 'undefined') {
      // Obtener el token de autenticación de localStorage
      this.token = localStorage.getItem('token');
      console.log("token recuperado", this.token);
      // Si el token no es nulo, entonces obtener las transacciones
      if (this.token !== null) {
        this.obtenerTransacciones();
      } else {
        console.error('Token de autenticación no encontrado en localStorage');
      }
    } else {
      console.error('localStorage no está disponible en este entorno');
    }
  }

  obtenerTransacciones(): void {
    if (!this.token) {
      console.error('El token es nulo.');
      return;
    }
  corchete de expecion asdasjava
    // Eliminar las comillas dobles del principio y del final de la cadena
    const tokenString = this.token.replace(/^"|"$/g, '');
  
    // Eliminar las barras invertidas de la cadena
    const tokenWithoutBackslashes = tokenString.replace(/\\/g, '');
  
    const headers = new HttpHeaders ({
      'Authorization': `Bearer ${tokenWithoutBackslashes}`
    });
    
    console.log("headers", headers);
    
    this.http.get<any[]>('https://localhost:7064/api/transacciones/ObtenerTodasLasTransacciones', { headers })
      .subscribe(
        (data: any[]) => {
          console.log(data)
          this.transacciones = data;
        },
        error => {
          console.error('Error al obtener transacciones:', error);
        }
      );
  }
}