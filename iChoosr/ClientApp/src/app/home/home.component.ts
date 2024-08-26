import { Component, OnInit } from '@angular/core';
import * as L from 'leaflet';
import { CameraService } from '../camera/services/cameraService';
import { DivideCameras } from '../camera/models/CameraResponse ';
import { Camera } from '../camera/models/camera';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  private map!: L.Map;
  private cameras: Camera[] = [];
  dividedCameras!: DivideCameras; 

  constructor(private cameraService: CameraService) { }

  ngOnInit(): void {
    this.initMap();
    this.fetchCameras();
    this.cameraService.getAllCameras().subscribe(cameras => {
      this.cameras = cameras;
      this.addMarkers();
    });
    
  }

  private fetchCameras(): void {
    this.cameraService.getCameras().subscribe(cameras => {
      this.dividedCameras = cameras;
    });
  }

  private initMap(): void {
    this.map = L.map('map', {
      center: [52.0907, 5.1214], 
      zoom: 12
    });

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(this.map);
  }

  private addMarkers(): void {
    this.cameras.forEach(camera => {
      L.marker([camera.latitude, camera.longitude])
        .bindPopup(`<b>${camera.name}</b><br>Latitude: ${camera.latitude}<br>Longitude: ${camera.longitude}`)
        .addTo(this.map);
    });
  }
}