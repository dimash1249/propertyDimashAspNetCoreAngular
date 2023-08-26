import { Component, OnInit } from '@angular/core';
import { PropertyService } from '../../shared/property.service';
import { UserService } from '../../user/user.service';
import { Property } from '../property';

@Component({
  selector: 'app-property-index',
  templateUrl: './property-index.component.html',
  styleUrls: ['./property-index.component.css']
})
export class PropertyIndexComponent implements OnInit {
  properties: Property[] = [];
  constructor(private PropertyService: PropertyService, public UserService: UserService) { }

  ngOnInit(): void {
    this.PropertyService.getProperties().subscribe((data: Property[]) => {
      this.properties = data;
      console.log(this.properties);
    });
  }

  deleteProperty(id: string) {
    this.PropertyService.deleteProperty(id).subscribe(res => {
      this.properties = this.properties.filter(item => item.id != id);
    });
  }
}
