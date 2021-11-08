using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Balance2.Content.Projectiles
{
    public class SpearGoldProjectile : ModProjectile
    {
        public override string Texture => "Balance2/Assets/Textures/Projectiles/SpearGoldProjectile";
        public override void SetDefaults()
        {
            Projectile.height = 15;
            Projectile.width = 15;
            Projectile.scale = 1.25f;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 19;

            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.ownerHitCheck = true;
        }

        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            Vector2 mountedCenter = owner.RotatedRelativePoint(owner.MountedCenter, true);
            Projectile.direction = owner.direction;
            owner.itemTime = owner.itemAnimation;
            owner.heldProj = Projectile.whoAmI;

            Projectile.position.X = mountedCenter.X - (float)(Projectile.width / 2);
            Projectile.position.Y = mountedCenter.Y - (float)(Projectile.height / 2);

            if (!owner.frozen)
            {
                if (movementFactor == 0)
                {
                    movementFactor = 3f;
                    Projectile.netUpdate = true;
                }

                if (owner.itemAnimation < owner.itemAnimationMax / 3)
                {
                    movementFactor -= 2.4f;
                }
                else
                {
                    movementFactor += 2.1f;
                }
            }

            Projectile.position += Projectile.velocity * movementFactor;

            if (owner.itemAnimation == 0)
            {
                Projectile.Kill();
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (Projectile.direction == -1)
            {
                Projectile.rotation -= MathHelper.ToRadians(90f);
            }
        }
    }
}
