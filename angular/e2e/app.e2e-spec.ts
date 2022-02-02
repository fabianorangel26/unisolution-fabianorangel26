import { FabianoRangel26TemplatePage } from './app.po';

describe('FabianoRangel26 App', function() {
  let page: FabianoRangel26TemplatePage;

  beforeEach(() => {
    page = new FabianoRangel26TemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
