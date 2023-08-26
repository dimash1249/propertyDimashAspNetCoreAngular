import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-news-image',
  templateUrl: './news-image.component.html',
  styleUrls: ['./news-image.component.css']
})
export class NewsImageComponent implements OnInit {
  progress: number = 0;
  message: string = "";
  @Output() public onUploadFinished = new EventEmitter();
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  uploadFile = (files: any) => {
    if (files.length == 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    console.log(formData);
    this.http.post('https://localhost:7074/api/NewsImage', formData, { reportProgress: true, observe: 'events' }).subscribe({
      next: (event) => {
        if (event.type == HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded);
        else if (event.type == HttpEventType.Response) {
          this.message = 'Upload success';
          this.onUploadFinished.emit(event.body);
        }
      },
      error: (err: HttpErrorResponse) => console.log(err)
    });
  }

}
