import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { PropertyImageList } from './property-image-list';

@Injectable({
  providedIn: 'root'
})
export class PropertyImageService {
  BaseUrl: string = "https://localhost:7074/api";
  constructor(private http: HttpClient) {
    
  }

  UploadPropertyImage(formData: FormData) {
    this.http.post(this.BaseUrl + '/PropertyImage', formData).subscribe((response) => {
      console.log('Image uploaded successfully');
    },
      (error) => {
        console.error('Error');
      });
  }
}
