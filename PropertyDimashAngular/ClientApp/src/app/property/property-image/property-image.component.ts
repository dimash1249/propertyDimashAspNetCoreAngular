import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { PropertyImage } from '../property-image';
import { PropertyImageList } from '../property-image-list';
import { PropertyImageService } from '../property-image.service';

@Component({
  selector: 'app-property-image',
  templateUrl: './property-image.component.html',
  styleUrls: ['./property-image.component.css']
})
export class PropertyImageComponent implements OnInit {
  message: string = "";
  @Output() public onUploadFinished = new EventEmitter();
  constructor(private http: HttpClient) { }

  ngOnInit(): void { }
  
  uploadFile = (files: any) => {
    if (files.length == 0) {
      return;
    }
    const formData = new FormData();
    let i = 0;
    for (let file of files) {
      let fileToUpload = <File>files[i];
      i++;
      console.log(fileToUpload);
      formData.append('file', fileToUpload, fileToUpload.name);
      console.log(formData);

      console.log(formData);
      this.http.post('https://localhost:7074/api/NewsImage', formData, { reportProgress: true, observe: 'events' }).subscribe({
        next: (event) => {
          if (event.type == HttpEventType.Response) {
            this.message = "Upload success";
            this.onUploadFinished.emit(event.body);
          }
        },
        error: (err: HttpErrorResponse) => console.log(err)
      });
    }
  }
  
}
