import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { News } from '../news';
import { NewsService } from '../news.service';

@Component({
  selector: 'app-news-details',
  templateUrl: './news-details.component.html',
  styleUrls: ['./news-details.component.css']
})
export class NewsDetailsComponent implements OnInit {
  id: string = "";
  news!: News;
  imageData: any;
  constructor(private NewsService: NewsService, private route: ActivatedRoute, private router: Router, private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['newsId'];
    this.NewsService.getNewsArticles(this.id).subscribe((data: News) => {
      this.news = data;
    });
    //this.imageData = btoa(new Uint8Array(this.news.ImageNews).reduce((data, byte) => data + String.fromCharCode(byte), ''));
    this.imageData = this.sanitizer.bypassSecurityTrustUrl('data:image/png;base64,' + this.news.imageNews);

  }

}
