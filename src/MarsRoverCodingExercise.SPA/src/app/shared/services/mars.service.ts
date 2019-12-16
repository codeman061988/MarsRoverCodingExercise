import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Image } from '../models/image';
import { ImageResponse } from '../models/image-response';

const API_URL = environment.apiUrl;
const MARS_PHOTOS_URL = `${API_URL}/v1/mars-photos/`;

@Injectable({
  providedIn: 'root'
})
export class MarsService {

  constructor(private http: HttpClient) { }

  /**
* Retrieves images takes by a specified mars rover, by the name of the mars rover name
* @param roverName
*/
  public getPhotosByRoverName(roverName: string): Observable<ImageResponse> {
    return this.http.get<ImageResponse>(`${MARS_PHOTOS_URL}${roverName}`);
  }
}
