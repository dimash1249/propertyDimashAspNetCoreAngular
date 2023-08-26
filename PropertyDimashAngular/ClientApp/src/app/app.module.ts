import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { PropertyCreateComponent } from './property/property-create/property-create.component';
import { PropertyDetailsComponent } from './property/property-details/property-details.component';
import { PropertyDeleteComponent } from './property/property-delete/property-delete.component';
import { PropertyImageComponent } from './property/property-image/property-image.component';
import { PropertyIndexComponent } from './property/property-index/property-index.component';
import { PropertyCreateFlatComponent } from './property/property-create/property-create-flat/property-create-flat.component';
import { PropertyCreateHouseComponent } from './property/property-create/property-create-house/property-create-house.component';
import { ResidentialComplexIndexComponent } from './residentialComplex/residential-complex-index/residential-complex-index.component';
import { ResidentialComplexCreateComponent } from './residentialComplex/residential-complex-create/residential-complex-create.component';
import { NewsCreateComponent } from './news/news-create/news-create.component';
import { NewsIndexComponent } from './news/news-index/news-index.component';
import { NewsImageComponent } from './news/news-image/news-image.component';
import { NewsDetailsComponent } from './news/news-details/news-details.component';
import { UserRegistrationComponent } from './user/user-registration/user-registration.component';
import { UserComponent } from './user/user/user.component';
import { ForbiddenComponent } from './forbidden/forbidden/forbidden.component';
import { AuthGuard } from './user/auth.guard';
import { NavHomeComponent } from './home/nav-home/nav-home.component';
import { AuthInterceptor } from './user/auth.interceptor';
import { UserService } from './user/user.service';
import { ResidentialComplexDetailsComponent } from './residentialComplex/residential-complex-details/residential-complex-details.component';
import { PricePredictionOfPropertyComponent } from './property/price-prediction-of-property/price-prediction-of-property.component';

@NgModule({
  declarations: [
    AppComponent,
    PropertyIndexComponent,
    PropertyCreateComponent,
    PropertyDetailsComponent,
    PropertyDeleteComponent,
    PropertyCreateFlatComponent,
    PropertyCreateHouseComponent,
    ResidentialComplexIndexComponent,
    ResidentialComplexCreateComponent,
    NewsCreateComponent,
    NewsIndexComponent,
    NewsImageComponent,
    NewsDetailsComponent,
    UserRegistrationComponent,
    UserComponent,
    ForbiddenComponent,
    HomeComponent,
    NavHomeComponent,
    ResidentialComplexDetailsComponent,
    PropertyCreateFlatComponent,
    PropertyImageComponent,
    PricePredictionOfPropertyComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'properties', redirectTo: 'properties/index', pathMatch: 'full' },
      { path: 'properties/index', component: PropertyIndexComponent },
      { path: 'properties/:propertyId/details', component: PropertyDetailsComponent },
      { path: 'properties/create', component: PropertyCreateComponent },
      { path: 'UploadDocument', component: PropertyImageComponent },
      { path: 'residential-complexes/index', component: ResidentialComplexIndexComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Admin', 'Moderator'] } },
      { path: 'residential-complexes/create', component: ResidentialComplexCreateComponent },
      { path: 'news/create', component: NewsCreateComponent },
      { path: 'news/index', component: NewsIndexComponent },
      { path: 'news/:newsId/details', component: NewsDetailsComponent },
      { path: 'user/registration', component: UserRegistrationComponent },
      { path: 'user/login', component: UserComponent },
      { path: 'forbidden', component: ForbiddenComponent },
      { path: 'residential-complexes/:residentialComplexId/details', component: ResidentialComplexDetailsComponent },
      { path: 'properties/:type/:propertyType/create', component: PropertyCreateFlatComponent },
      { path: 'properties/price-prediction-of-house', component: PricePredictionOfPropertyComponent },
    ])
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
