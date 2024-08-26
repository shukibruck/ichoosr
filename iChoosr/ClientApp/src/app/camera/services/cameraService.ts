import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { Camera } from "../models/camera";
import { CameraResponse, DivideCameras } from "../models/CameraResponse ";

@Injectable({
    providedIn: 'root'
  })
  export class CameraService {
    private apiUrl = 'http://localhost:5079/api/camera';
  
    constructor(private http: HttpClient) {}
  
    getCameras(): Observable<DivideCameras> {
      return this.http.get<CameraResponse>(this.apiUrl).pipe(
        map(response => response.value.value)
      );
    }
  
    getAllCameras(): Observable<Camera[]> {
      return this.getCameras().pipe(
        map(data => [
          ...data.dividedByThree,
          ...data.dividedByFive,
          ...data.dividedByThreeAndFive,
          ...data.undivided
        ])
      );
    }
  
    getCamerasByDivision(division: 'dividedByThree' | 'dividedByFive' | 'dividedByThreeAndFive' | 'undivided'): Observable<Camera[]> {
      return this.getCameras().pipe(
        map(data => data[division])
      );
    }
  }