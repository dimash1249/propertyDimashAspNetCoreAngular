import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NewsService } from '../news.service';
import { v4 as uuidv4 } from 'uuid';
import { formatDate } from '@angular/common';
import { UserService } from '../../user/user.service';

@Component({
  selector: 'app-news-create',
  templateUrl: './news-create.component.html',
  styleUrls: ['./news-create.component.css']
})
export class NewsCreateComponent implements OnInit {
  id: string = "";
  publishedDate: string;
  newsForm;
  imageNews!: File;
  response: any = { dbPath: '' };
  constructor(private NewsService: NewsService, private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder, private UserService: UserService) {
    this.id = uuidv4();
    this.publishedDate = formatDate(new Date(), 'dd/MM/yyyy hh:mm', 'en-Asia', '+0600');
    this.newsForm = this.formBuilder.group({
      id: [this.id],
      title: ['', Validators.required],
      description: ['', Validators.required],
      imageAuthor: ['', Validators.required],
      imageNews: ['', Validators.required],
      newsType: ['', Validators.required],
      publishedDate: [this.publishedDate],
      userId: [this.UserService.getUserId.value],
    });
  }

  ngOnInit(): void {
  }

  onFileChange(event: any) {
    //this.imageNews = event.target.files[0];
    //const fileInput = event.target as HTMLInputElement;
    //const file: File = (fileInput.files as FileList)[0];
    //this.newsForm.patchValue({ ImageNews: this.imageNews });
  }

  onSubmit(formData: any) {
    //const formDataD = new FormData();
    this.newsForm.patchValue({ imageNews: this.response.message });//formDataD.append('ImageNews', this.imageNews);
    this.NewsService.createNews(formData.value).subscribe(res => {
      this.router.navigateByUrl('/news/index');
    });
    console.log(formData);
  }

  uploadFinished = (event: any) => {
    this.response = event;
    console.log(this.response.message)
  }
}
