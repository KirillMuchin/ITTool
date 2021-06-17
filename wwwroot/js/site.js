


class TabList {
    constructor(buttonsContainer, tabs) {
        this.buttonsContainer = buttonsContainer;
        this.tabs = tabs;

        this.buttonsContainer.addEventListener('click', event => {
            const index = event.target.closest('.button').dataset.value;

            this.openTab(index);
        });
    }

    openTab(index) {
        this.buttonsContainer.querySelector('.active-button').classList.remove('active-button');
        this.buttonsContainer.querySelector(`.button--${index}`).classList.add('active-button');
        this.tabs.querySelector('.active').classList.remove('active');
        this.tabs.querySelector(`.tab--${index}`).classList.add('active');
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const buttonsContainer = document.querySelector('.buttons');
    const tabs = document.querySelector('.tabs');

    const tabList = new TabList(buttonsContainer, tabs);
})


