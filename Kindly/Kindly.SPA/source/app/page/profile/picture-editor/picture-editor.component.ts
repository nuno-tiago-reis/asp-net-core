// components
import { Component, OnInit, Input } from '@angular/core';
import { FileUploader, FileItem, ParsedResponseHeaders } from 'ng2-file-upload';

// services
import { AuthService } from '../../../-services/auth/auth.service';
import { PicturesService } from '../../../-services/pictures/pictures.service';
import { AlertifyService } from '../../../-services/alertify/alertify.service';

// models
import { Picture } from '../../../-models/picture';

// environment
import { environment } from '../../../../environments/environment';

@Component
({
	selector: 'app-picture-editor',
	templateUrl: './picture-editor.component.html',
	styleUrls: [ './picture-editor.component.css' ]
})

export class PictureEditorComponent implements OnInit
{
	/**
	 * The pictures.
	 */
	@Input()
	public pictures: Picture[];

	/**
	 * The picture uploader.
	 */
	public uploader: FileUploader;

	/**
	 * Whether there are files over the drop zone.
	 */
	public hasFileOverDropZone: boolean;

	/**
	 * Creates an instance of the picture editor component.
	 *
	 * @param authApi The auth service.
	 * @param picturesApi The pictures service.
	 * @param alertify The alertify service.
	 */
	public constructor
	(
		private readonly authApi: AuthService,
		private readonly picturesApi: PicturesService,
		private readonly alertify: AlertifyService
	)
	{
		// Nothing to do here.
	}

	/**
	 * A lifecycle hook that is called after Angular has initialized all data-bound properties of a directive.
	 */
	public ngOnInit (): void
	{
		this.uploader = new FileUploader
		({
			url: environment.apiUrl + 'users/' + this.authApi.user.id + '/pictures',
			authToken: `Bearer ${this.authApi.encodedToken}`,
			isHTML5: true,
			allowedFileType: ['image'],
			removeAfterUpload: true,
			autoUpload: false,
			maxFileSize: 10 * 1024 * 1024
		});

		this.uploader.onAfterAddingFile = (file: FileItem) =>
		{
			file.withCredentials = false;
		};

		this.uploader.onSuccessItem = (item: FileItem, response: string, status: number, headers: ParsedResponseHeaders) =>
		{
			console.log(status + `: ${this.uploader.options.url} successfull`);

			if (response)
			{
				const result: Picture = JSON.parse(response);
				const picture: Picture =
				{
					id: result.id,
					url: result.url,
					publicID: result.publicID,
					createdAt: result.createdAt,
					description: result.description,
					isApproved: result.isApproved,
					isProfilePicture: result.isProfilePicture,
					userID: result.userID
				};

				if (this.pictures === null || this.pictures.length === 0)
				{
					// emit the profile picture change
					this.authApi.setProfilePictureUrl(picture.url);
				}

				this.pictures.push(picture);

				// console.log(`You have uploaded ${item.file.name} successfully.`);
				this.alertify.success(`You have uploaded ${item.file.name} successfully.`);
			}
		};

		this.uploader.onErrorItem = (item: FileItem, response: string, status: number, headers: ParsedResponseHeaders) =>
		{
			// console.error(`An error occured uploading ${item.file.name}: ${response}`);
			this.alertify.error(`An error occured while uploading ${item.file.name}.`);
		};
	}

	/**
	 * Invoked when the file is over the drag-and-drop area.
	 */
	public fileOverDropZone(event: any): void
	{
		this.hasFileOverDropZone = event;
	}

	/**
	 * Sets a picture as the profile picture.
	 *
	 * @param picture The picture to set as profile picture.
	 */
	public setProfilePicture(picture: Picture)
	{
		picture.isProfilePicture = true;

		this.picturesApi.update(picture.id, picture.userID, picture).subscribe
		(
			(next: void) =>
			{
				// update the previous profile picture
				const profilePictures = this.pictures.filter(p => p.isProfilePicture);
				for (let i = 0; i < profilePictures.length; i++)
					profilePictures[i].isProfilePicture = false;

				// update the current profile picture
				picture.isProfilePicture = true;

				// emit the profile picture change
				this.authApi.setProfilePictureUrl(picture.url);

				this.alertify.success('You have updated the profile picture.');
			},
			(error: any) =>
			{
				this.alertify.error('An error occured while updating the picture.');
			}
		);
	}

	/**
	 * Deletes a picture
	 */
	public deletePicture(picture: Picture)
	{
		this.alertify.confirm('Delete Picture', 'Are you sure you want to delete this picture?',
		() =>
		{
			this.picturesApi.delete(picture.id, picture.userID).subscribe
			(
				(next: void) =>
				{
					this.pictures.splice(this.pictures.findIndex(p => p.id === picture.id), 1);
					this.alertify.success('You have deleted the picture.');
				},
				(error: any) =>
				{
					this.alertify.error('An error occured while deleting the picture.');
				}
			);
		},
		() =>
		{
			// Nothing to do here.
		});
	}

	/**
	 * Gets the profile tooltip message.
	 *
	 * @param picture The picture.
	 */
	public getProfileTooltipMessage(picture: Picture)
	{
		if (picture.isProfilePicture)
			return 'This is the profile picture.';
		else
			return 'Set as profile picture?';
	}

	/**
	 * Gets the delete tooltip message.
	 *
	 * @param picture The picture.
	 */
	public getDeleteTooltipMessage(picture: Picture)
	{
		if (picture.isProfilePicture)
			return 'Cannot delete the profile picture.';
		else
			return 'Delete this picture?';
	}
}