import { Component } from '@angular/core';
import { Image } from './shared/models/image';
import { MarsService } from './shared/services/mars.service';
import { environment } from 'src/environments/environment';

const BASE_URL = environment.imageUrlBase;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  // The collection of images used on the page
  images: Image[];
  loading = false;
  noContent = false;
  baseUrl = BASE_URL;

  constructor(
    private marsService: MarsService
  ) { }

  /**
   * Handles image load from service
   * @param roverName
   */
  loadImages(roverName: string) {
    this.loading = true;
    this.noContent = false;
    this.marsService
      .getPhotosByRoverName(roverName)
      .subscribe((result) => {
        this.loading = false;
        this.images = result.marsImages;
        this.noContent = (!result || result.marsImages.length === 0);
      });
  }

}
