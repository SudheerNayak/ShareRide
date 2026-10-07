import { Component, inject, OnInit } from '@angular/core';
import { RideService } from '../../../../core/services/ride.service';
import { response } from 'express';
import { Ride } from '../../../../core/models/ride.model';

@Component({
  selector: 'app-ride-list',
  imports: [],
  templateUrl: './ride-list.component.html',
  styleUrl: './ride-list.component.css'
})
export class RideListComponent implements OnInit {

  private readonly rideService = inject(RideService)
  rides: Ride[] = [];
  isLoading = false;
  errorMessage = '';

  ngOnInit(): void {
    this.loadRide();
  }
  private loadRide(): void {
    this.isLoading = true;
    this.rideService.getRides().subscribe({
      next: (response) => {
        this.rides = response;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error loading rides ', error);
        this.errorMessage = 'Unable to load ride',
          this.isLoading = false;
      }
    })
  }

}
