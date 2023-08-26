import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserService } from '../../user/user.service';
import { News } from '../news';
import { NewsService } from '../news.service';

@Component({
  selector: 'app-news-index',
  templateUrl: './news-index.component.html',
  styleUrls: ['./news-index.component.css']
})
export class NewsIndexComponent implements OnInit {
  newsList: News[] = [];
  isNews: boolean = false;
  isArticles: boolean = false;
  userId: string = "";
  constructor(private NewsService: NewsService, public UserService: UserService) { }

  ngOnInit(): void {
    this.NewsService.getNews().subscribe((data: News[]) => {
      this.newsList = data;
      console.log(this.newsList);
    });
    this.userId = this.UserService.getUserId.value;
  }

  deleteNews(id: string) {
    this.NewsService.deleteNews(id).subscribe(res => {
      this.newsList = this.newsList.filter(item => item.id != id);
    });
  }

  all() {
    this.isNews = false;
    this.isArticles = false;
  }

  news() {
    this.isNews = false;
    this.isArticles = true;
  }

  articles() {
    this.isNews = true;
    this.isArticles = false;
  }
}
