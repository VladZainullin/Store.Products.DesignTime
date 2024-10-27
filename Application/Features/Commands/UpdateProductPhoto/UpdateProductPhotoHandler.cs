using Application.Contracts.Features.Commands.UpdateProductPhoto;
using Domain.Entities.Products.Parameters;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Products.Parameters;

namespace Application.Features.Commands.UpdateProductPhoto;

internal sealed class UpdateProductPhotoHandler(IDbContext context, IMinioClient minioClient, TimeProvider timeProvider)
    : IRequestHandler<UpdateProductPhotoCommand>
{
    public async Task Handle(UpdateProductPhotoCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.GetAsync(new GetProductByIdParameters
        {
            Id = request.RouteDto.ProductId,
            CancellationToken = cancellationToken
        });
        
        product.UpdatePhoto(new SetProductPhotoParameters
        {
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);

        const string productPhotosBucket = "product-photos";
        var bucketExists = await minioClient.BucketExistsAsync(
            new BucketExistsArgs()
                .WithBucket(productPhotosBucket), cancellationToken);
        if (!bucketExists)
        {
            await minioClient.MakeBucketAsync(new MakeBucketArgs()
                .WithBucket(productPhotosBucket), cancellationToken);
        }

        await minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(productPhotosBucket)
            .WithObject(product.Photo.ToString())
            .WithStreamData(request.FormDto.Photo.OpenReadStream()), cancellationToken);
    }
}