import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'crudAngular';
  // In your component class
public selectAll = false;
public options = [{name: "Option 1", selected: false}, {name: "Option 2", selected: false}, {name: "Option 3", selected: false}];

// Method to handle the change event on the "select all" option
public onSelectAllChange() {
  this.options.forEach(option => {
    if(this.selectAll)
      option.selected = true;
    else
      option.selected = false;
  });
}

// Method to handle the change event on the other options
public onOptionChange() {
  this.selectAll = this.options.every(option => option.selected);
}
}
