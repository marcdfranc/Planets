export interface PageHeaderAttributes {
	content: string;
	subContent?: string;
	imgUrl?: string;
}

export class PageHeaderAttributes implements PageHeaderAttributes {
	constructor(init: PageHeaderAttributesValues) {
		Object.assign(this, init);
	}
}

export class PageHeaderAttributesValues {
	content: string = '';
	subContent?: string = '';
	imgUrl?: string = '';

	constructor(pageHeaderAttributes?: PageHeaderAttributes) {
		if (pageHeaderAttributes) {
			this.content = pageHeaderAttributes.content;
			this.subContent = pageHeaderAttributes.subContent;
			this.imgUrl = pageHeaderAttributes.imgUrl;
		}
	}
}