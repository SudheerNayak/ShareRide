import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path:'', redirectTo:'rides', pathMatch:'full'
  },
  {
    path: 'rides', loadComponent: () =>
      import('./features/rides/pages/ride-list/ride-list.component')
      .then(m => m.RideListComponent)
  },
  {
    path: 'rides/id', loadComponent: () =>
      import('./features/rides/pages/ride-details/ride-details.component')
        .then(m => m.RideDetailsComponent)
  },
  {
    path: 'rides/create', loadComponent: () =>
      import('./features/rides/pages/create-ride/create-ride.component')
        .then(m => m.CreateRideComponent)
  },
  {
    path:'**', redirectTo:'rides'
  }

];
