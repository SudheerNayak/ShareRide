import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import {Ride } from '../models/ride.model'

@Injectable({
  providedIn: 'root'
})
export class RideService {

  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'https://localhost:7253/api/rides';
  getRides(): Observable<Ride[]> {
    return this.http.get<Ride[]>(this.apiUrl);
  }
  getRideById(id: number): Observable<Ride> {
    return this.http.get<Ride>(`${this.apiUrl} / ${id}`);
  }

}
