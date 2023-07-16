export interface PageHeaderAttributes {
	content: string;
	subContent?: string;
}

export class PageHeaderAttributes implements PageHeaderAttributes {
	constructor(init: PageHeaderAttributesValues) {
		Object.assign(this, init);
	}
}

export class PageHeaderAttributesValues {
	content: string = '';
	subContent?: string = '';

	constructor(pageHeaderAttributes?: PageHeaderAttributes) {
		if (pageHeaderAttributes) {
			this.content = pageHeaderAttributes.content;
			this.subContent = pageHeaderAttributes.subContent;
		}
	}
}